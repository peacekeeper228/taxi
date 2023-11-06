### Problem A

Simply run ProblemA.py. Then you will need to input text, keywords separated by spaces, context size and search phrase. To stop program input "$70p".

Results will be outputted in output.csv file (delimiter is tabulation).

Method used for solving Problem A is Pipes-and-Filters. In the main process input data is gathered, then it is being sent to parser, where KWIC are calculated. After that KWIC and search phrase are passed in searcher where contexts for words in phrase are being found and written in output file.

#### Sample arguments for testing

`I love seeing those kids playing in the backyard, it reminds me of times I was young and full of energy.`

`kids backyard times`

`3`

`kids playing in the backyard`

### Problem B

For calculating results run ProblemB.py. After execution is complete all solutions will be printed in terminal. No input arguments needed.

Method used for solving Problem B is Abstract data types. Two classes were elicited: Queen and SolverService. Queen contains data about position of the figure and has method for checking if it is on guarded by any queen cell (also it has one method for pretty output of data). SolverService has two methods: one for entering solving recursion and another one for calculating solutions for fewer number of queens.