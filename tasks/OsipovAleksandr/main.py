import multiprocessing
from multiprocessing import Process
from time import sleep

def inputChecker(sendDataPortFromInput):
    for _ in range(10):
        sendDataPortFromInput.send(8)
        sleep(5)

    sendDataPortFromInput.send(None)
    

def Solver(receiveDataPortToSolver, sendDataPortFromSolver):
    while True:
        n = receiveDataPortToSolver.recv()
        
        if n is None:
            print("Solver has solved all tasks")
            sendDataPortFromSolver.send(None)
            break
        
        solutions = solve(n)
        sendDataPortFromSolver.send(solutions)

def Output(receiveDataPortToOutput):
    while True:
        n = receiveDataPortToOutput.recv()
        
        if n is None:
            print("Output has printed all tasks")
            break

        print(n)
    

def under_attack(column, existing_queens): # You do not need to fill in these fields. This is a helper function for the solve function.
    # ASSUMES that row = len(existing_queens) + 1
    row = len(existing_queens)+1
    for queen in existing_queens:
        r,c = queen
        if r == row: return True # Check row
        if c == column: return True # Check column
        if (column-c) == (row-r): return True # Check left diagonal
        if (column-c) == -(row-r): return True # Check right diagonal
    return False

def solve(n):
    if n == 0: return [[]] # No RECURSION if n=0. 
    smaller_solutions = solve(n-1) # RECURSION!!!!!!!!!!!!!!
    solutions = []
    for solution in smaller_solutions:# I moved this around, so it makes more sense
        for column in range(1,8+1): # I changed this, so it makes more sense
            # try adding a new queen to row = n, column = column 
            if not under_attack(column , solution): 
                solutions.append(solution + [(n,column)])
    return solutions

if __name__ == '__main__':
    receiveDataPortToSolver, sendDataPortFromInput = multiprocessing.Pipe(duplex=False)
    receiveDataPortToOutput, sendDataPortFromSolver = multiprocessing.Pipe(duplex=False)
    p = Process(target=inputChecker, args=(sendDataPortFromInput,))
    p.start()

    p1 = Process(target=Solver, args=(receiveDataPortToSolver, sendDataPortFromSolver,))
    p1.start()

    p2 = Process(target=Output, args=(receiveDataPortToOutput,))
    p2.start()
    
    p.join()
    p1.join()
    p2.join()