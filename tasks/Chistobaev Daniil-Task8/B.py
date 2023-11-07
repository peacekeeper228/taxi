

class Subject:
    def __init__(self):
        self._observers = []  # Список наблюдателей

    def register_observer(self, observer):
        self._observers.append(observer)  # Регистрация наблюдателя

    def notify_observers(self, event, data):
        for observer in self._observers:
            observer.update(event, data)  # Уведомление наблюдателей о событии

class Observer:
    def update(self, event, data):
        pass  # Метод, который должны реализовать наблюдатели

class EightQueensSolver(Observer):
    def __init__(self, size=8):
        self.size = size  # Размер доски
        self.solutions = []  # Список найденных решений

    def update(self, event, data):
        if event == 'solve':
            self.solve()  # Если событие - решение, то начать решение

    def solve(self):
        self.place_queen(0)  # Начать процесс размещения ферзей

    def is_safe(self, board, row, col):
        # Проверка безопасности размещения ферзя
        for i in range(row):
            if board[i] == col or \
               board[i] - i == col - row or \
               board[i] + i == col + row:
                return False
        return True

    def place_queen(self, row, board=None):
        # Рекурсивное размещение ферзя
        if board is None:
            board = [-1] * self.size
        if row == self.size:
            self.solutions.append(board[:])  # Если доска заполнена, добавить решение
            return
        for col in range(self.size):
            if self.is_safe(board, row, col):
                board[row] = col
                self.place_queen(row + 1, board)
                board[row] = -1  # Возврат, если позиция оказалась небезопасной

    def get_solutions(self):
        return self.solutions  # Получение списка решений

# Создание субъекта (издателя событий)
subject = Subject()

# Создание решателя задачи о восьми ферзях и его регистрация как наблюдателя
solver = EightQueensSolver()
subject.register_observer(solver)

# Имитация события, которое запускает решение головоломки
subject.notify_observers('solve', None)

# Получение и вывод количества решений
num_solutions = len(solver.get_solutions())

# Вывод всех решений в консоль
for solution in solver.get_solutions():
    print(solution)
