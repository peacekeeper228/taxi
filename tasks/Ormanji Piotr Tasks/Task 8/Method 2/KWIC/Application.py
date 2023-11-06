from DocumentHandler import DocumentHandler
from KWICHandler import KWICHandler


path = input("Укажите путь к файлу: ")
keyWord = input("Укажите ключевое слово: ")
contextSize = input("Укажите макс. количество слов по сторонам ключевого слова: ")

extractedText = DocumentHandler.ExtractTextFromFile(path)
kwic = KWICHandler.GetKWIC(extractedText, keyWord, contextSize)

print(kwic)
