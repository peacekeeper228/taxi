
class KWICIndexer:
    def __init__(self, text, keyword, context_size):
        self.text = text
        self.keyword = keyword.lower()  # Преобразование ключевого слова в нижний регистр для поиска без учета регистра.
        self.context_size = context_size
        self.subscribers = []

    def subscribe(self, listener):
        self.subscribers.append(listener)

    def index(self):
        # Разделение текста на строки
        lines = self.text.split('\n')
        for line in lines:
            words = line.split()
            # Итерация по словам и уведомление подписчиков, если слово совпадает с ключевым словом
            for i, word in enumerate(words):
                # Проверка совпадения текущего слова с указанным ключевым словом, без учета регистра и пунктуации
                if ''.join(filter(str.isalnum, word)).lower() == self.keyword:
                    event = {'word': word, 'context': line, 'position': i}
                    self.notify(event)

    def notify(self, event):
        for subscriber in self.subscribers:
            subscriber.update(event)


class KWICListener:
    def __init__(self, context_size):
        self.context_size = context_size
        self.index = []

    def update(self, event):
        # Создание строки KWIC с ключевым словом в центре
        words = event['context'].split()
        start = max(event['position'] - self.context_size, 0)
        end = event['position'] + self.context_size + 1
        left_context = ' '.join(words[start:event['position']])
        right_context = ' '.join(words[event['position'] + 1:end])
        self.index.append(f"{left_context} {event['word']} {right_context}".strip())

    def get_index(self):
        # Получение отсортированного индекса
        return sorted(self.index, key=lambda s: s.lower())



keyword = "Encyclopedia"  # Ключевое слово
context_size = 2   # Размер контекста 

# Пример текста,
text = """
KWIC is an acronym for Key Word In Context, the most common format for concordance lines. ... page 1
... Key Word In Context, the most common format for concordance lines. ... page 1
... the most common format for concordance lines. ... page 1
... is an acronym for Key Word In Context, the most common format ... page 1
Wikipedia, The Free Encyclopedia ... page 0
... In Context, the most common format for concordance lines. ... page 1
Wikipedia, The Free Encyclopedia ... page 0
KWIC is an acronym for Key Word In Context, the most ... page 1
KWIC is an acronym for Key Word ... page 1
... common format for concordance lines. ... page 1
... for Key Word In Context, the most common format for concordance ... page 1
Wikipedia, The Free Encyclopedia ... page 0
KWIC is an acronym for Key Word In Context, the most common ... page 1
"""

# Создание индексатора KWIC и слушателя с пользовательским ключевым словом и размером контекста
indexer = KWICIndexer(text, keyword, context_size)
listener = KWICListener(context_size)
indexer.subscribe(listener)

# Генерация индекса
indexer.index()

# Получение отсортированного индекса
kwic_index = listener.get_index()

# Вывод индекса KWIC
for line in kwic_index:
    print(line)
