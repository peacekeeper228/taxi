class KWICIndex:
    def __init__(self, text, keyword, context):
        # Инициализация: преобразование текста и ключевого слова в нижний регистр и разбиение текста на строки
        self.lines = text.lower().split('\n')
        self.keyword = keyword.lower()
        self.context = context  # Количество слов слева и справа от ключевого слова, которые будут включены в контекст
        self.matches = []  # Список для хранения строк, содержащих ключевое слово

    def find_matches(self):
        # Поиск строк, содержащих ключевое слово
        for line in self.lines:
            if self.keyword in line:
                self.matches.append(line)  # Добавление подходящей строки в список совпадений

    def get_context(self):
        # Получение контекста для каждого совпадения ключевого слова
        contexts = []  # Список для хранения контекстов
        for match in self.matches:
            words = match.split()  # Разбиение строки на слова
            try:
                position = words.index(self.keyword)  # Поиск позиции ключевого слова
                start = max(position - self.context, 0)  # Определение начальной позиции контекста
                end = position + self.context + 1  # Определение конечной позиции контекста
                context_string = " ".join(words[start:end])  # Сборка контекстной строки
                contexts.append(context_string)  # Добавление контекстной строки в список
                print(context_string)  # Вывод контекстной строки в консоль
            except ValueError:
                # Если ключевое слово не найдено, пропускаем эту итерацию
                pass
        return contexts  # Возвращение списка контекстов

# Текст для индексации
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


# Ключевое слово для поиска
keyword = "for"
# Размер контекста (количество слов до и после ключевого слова)
context_size = 2

# Создание экземпляра класса KWICIndex
kwic = KWICIndex(text, keyword, context_size)
# Поиск совпадений ключевого слова в тексте
kwic.find_matches()
# Получение контекстов для совпадений
kwic_contexts = kwic.get_context()

# Вывод контекстов в консоль
for context in kwic_contexts:
    print(context)
