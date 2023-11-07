import re
SPACE_SYMBOL = ' '
def occurrencesRight(string, counter, start):
    count = 0
    while True:
        start = string.find(SPACE_SYMBOL, start) + 1
        if start > 0:
            count+=1
            if count == counter:
                return start
        else:
            return -1
        
def occurrencesLeft(string, counter, start):
    count = 0
    while True:
        start = string.rfind(SPACE_SYMBOL, 0, start)
        if start > 0:
            count+=1
            if count == counter:
                return start
        else:
            return -1

def inputFun():
    s = "Таким образом, реализация намеченного плана развития требует от нас системного анализа системы обучения кадров, соответствующей насущным потребностям. Keyword что-то, а зачем. А ля ля"
    keywords = ['Keyword']
    return s, keywords

def getUserParams():
    numberOfWordContext = 5
    return numberOfWordContext

def analyzeKWIC(text, keywords, lengthOfContext):
    results = []
    for i in keywords:
        keywordIndexes = [m.start() for m in re.finditer(i, text)]
        for keywordIndex in keywordIndexes:
            leftDotSign = occurrencesLeft(text, lengthOfContext + 1, keywordIndex)
            if leftDotSign == -1:
                leftDotSign = 0
            rightDotSign = occurrencesRight(text, lengthOfContext + 1, keywordIndex)
            if rightDotSign == -1:
                rightDotSign == len(text)
            results.append(text[leftDotSign+1:rightDotSign-1])
    return results

def outputResults(results):
    print(results)

if __name__ == '__main__':
    text, keywords = inputFun()
    lengthOfContext = getUserParams()
    results = analyzeKWIC(text, keywords, lengthOfContext)
    outputResults(results)