class Queen:
    def __init__(self, x, y):
        self.x = x
        self.y = y

    def __str__(self):
        return f"Q({self.x}, {self.y})"

    def guarded(self, queens):
        for queen in queens:
            if queen.x == self.x:
                return True
            if queen.y == self.y:
                return True
            if (queen.y - self.y) == (queen.x - self.x):
                return True
            if (queen.y - self.y) == (self.x - queen.x):
                return True
        return False

class SolverService:
    def solve_board(self, queen_number):
        if queen_number == 0:
            return [[]]
        prev_queens = self.solve_board(queen_number - 1)
        cur_queens = []
        for queens in prev_queens:
            for column in range(1, 9):
                temp_queen = Queen(queen_number, column)
                if not temp_queen.guarded(queens):
                    cur_queens.append(queens + [temp_queen])
        return cur_queens

    def solve(self):
        return self.solve_board(8)

solutions = SolverService().solve()

for i in range(len(solutions)):
    title = f"Solution {i + 1}"
    print(f"{title:.^30}\n")
    for queen in solutions[i]:
        print(queen)
    print(f"{'':.^30}")
