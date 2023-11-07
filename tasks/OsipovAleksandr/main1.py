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

s = "Таким образом, реализация намеченного плана развития требует от нас системного анализа системы обучения кадров, соответствующей насущным потребностям. Keyword что-то, а зачем. А ля ля"
keywords = ['Keyword']
dotSign = '.'
results = []
for i in keywords:
    keywordIndexes = [m.start() for m in re.finditer(i, s)]
    for keywordIndex in keywordIndexes:
        leftDotSign = occurrencesLeft(s, 5, keywordIndex)
        if leftDotSign == -1:
            leftDotSign = 0
        rightDotSign = occurrencesRight(s, 5, keywordIndex)
        if rightDotSign == -1:
            rightDotSign == len(s)
        results.append(s[leftDotSign+1:rightDotSign])
print(results)