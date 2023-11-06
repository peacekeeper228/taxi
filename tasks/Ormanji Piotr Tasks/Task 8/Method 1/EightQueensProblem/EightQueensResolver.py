class EightQueensResolver:

    def ResolveProblem(table, column):

        if column >= len(table):
            return True

        for row in range(len(table)):
            
            if EightQueensResolver._IsGoodPlaceForQueen(table, row, column):
                table[row][column] = 1

                if EightQueensResolver.ResolveProblem(table, column + 1):
                    return True
                
                table[row][column] = 0

        return False
    
    def PrintTable(table):
        for row in table:
            print(' '.join(['Q' if cell == 1 else '.' for cell in row]))

    def _IsGoodPlaceForQueen(board, row, column):

        for i in range(column):
            if board[row][i] == 1:
                return False
   
        for i, j in zip(range(row, -1, -1), range(column, -1, -1)):
            if board[i][j] == 1:
                return False

        for i, j in zip(range(row, len(board), 1), range(column, -1, -1)):
            if board[i][j] == 1:
                return False

        return True