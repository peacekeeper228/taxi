class DocumentHandler :

    def ExtractTextFromFile(path):
        with open(path, 'r') as file:
            extractedText = file.read()
            return extractedText