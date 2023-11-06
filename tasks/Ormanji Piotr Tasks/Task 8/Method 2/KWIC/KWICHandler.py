import re

class KWICHandler:

    def GetKWIC(inputText, keyWord, contextSize):

        sentences = KWICHandler.GetSentences(inputText)
        clearSentences = KWICHandler.ClearSentences(sentences)
        context = KWICHandler.GetContext(clearSentences, keyWord, int(contextSize))
        
        return context
    
    def GetSentences(inputText):
        sentences = re.split(r'(?<=[.!?])\s+', inputText)
        sentences = [sentence.strip() for sentence in sentences if sentence.strip()]
        return sentences
    
    def ClearSentences(sentences):
        clearSentences = []
        for sentence in sentences:
            sentence = re.sub(r'[^\w\s]', '', sentence)
            sentence = re.sub(r'\s+', ' ', sentence)
            clearSentences.append(sentence)

        return clearSentences    
    
    def GetContext(sentences, keyword, contextSize):
        
        kwicList = []
        
        for sentence in sentences:
            
            words = sentence.split(" ")
            sentenceKwicList = []

            for index, word in enumerate(words):

                if(word.lower() == keyword.lower()):
                    keyWordIndex = index
                    leftContextIndex = 0 if keyWordIndex - contextSize < 0 else keyWordIndex - contextSize
                    rightContextIndex = len(words) - 1 if keyWordIndex + contextSize > len(words) - 1 else keyWordIndex + contextSize
                    context = " ".join(words[leftContextIndex:rightContextIndex + 1])
                    sentenceKwicList.append(context)

            if len(sentenceKwicList) != 0 :
                kwicList.append(" ".join(sentenceKwicList))
        
        return "\n".join(kwicList)
                