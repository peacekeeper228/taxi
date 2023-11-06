from multiprocessing import Process, Pipe

def parser(receiver2, out2):
    def parse_text(line):
        # array of tuples where elem is (start_index_of_token, token, end_index_of_token)
        tokens = []
        i = 0
        token_start = 0
        token = []
        for c in line:
            if c in ',.-!?"\' ':
                if len(token) != 0:
                    tokens.append((token_start, ''.join(token), i))
                    token = []
            else:
                if len(token) == 0:
                    token_start = i
                token.append(c)
            i += 1
        if len(token) != 0:
            tokens.append((token_start, ''.join(token), i))
        return tokens

    while True:
        cur_line = receiver2.recv()
        if isinstance(cur_line, str) and cur_line == '$70p':
            out2.send(cur_line)
            break
        text, keywords, context_size, phrase = cur_line
        parsed_text = parse_text(text)
        context_size = int(context_size)
        keywords = keywords.split()
        kwic = {}
        for keyword in keywords:
            for i in range(len(parsed_text)):
                if parsed_text[i][1] == keyword:
                    if keyword in kwic:
                        kwic[keyword].append(text[parsed_text[max(i - context_size, 0)][0]:parsed_text[min(len(parsed_text) - 1, i + context_size)][2]])
                    else:
                        kwic[keyword] = [text[parsed_text[max(i - context_size, 0)][0]:parsed_text[min(len(parsed_text) - 1, i + context_size)][2]]]
        out2.send([kwic, phrase])
    out2.close()
    receiver2.close()

def searcher(receiver3):
    with open("./output.csv", "w") as file:
        while True:
            data = receiver3.recv()
            if isinstance(data, str) and data == '$70p':
                break
            matches = []
            kwic, phrase = data
            for word in phrase.split():
                if word in kwic:
                    matches += kwic[word]
            file.write('\t'.join(matches))
            file.write('\n')
    receiver3.close()

if __name__ == "__main__":
    pipe1_in, pipe1_out = Pipe()
    pipe2_in, pipe2_out = Pipe()
    parser_process = Process(target=parser, args=(pipe1_out, pipe2_in,))
    searcher_process = Process(target=searcher, args=(pipe2_out,))
    parser_process.start()
    searcher_process.start()

    while True:
        print("Input text, keywords separated by spaces, context_size and phrase for search. Input '$70p' to stop program")

        data = []
        while len(data) != 4:
            cur_line = input()
            if cur_line == '$70p':
                pipe1_in.send(cur_line)
                break
            data.append(cur_line)
        if cur_line == '$70p':
            break
        pipe1_in.send(data)

    parser_process.join()
    searcher_process.join()
