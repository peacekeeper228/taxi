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

### Methods comparison

a) in which case it is easier to change the implementation algorithm in each of the modules?

Third method would be more convenient if you want to chane something in program logic as it is splitted into separate filters connected via pipes. Though you need to consider that in case when output of one of filters changes either input of another filter or pipe need to be changed.

b) in which solution it is easier (= seemingly less effort) to change data representation  

First method would suit for domain that changes over time as it is easier to change abstract models you written before.

c) in which solution it is easier to add additional functions to the modules

Event-driven methodology will be the best one for adding new logic as you can simply add new consumer that will handle already existent event model.

d) which solution is seemingly more performant?

I don't think there is the most performant methodology as performance depends on the code written when developing program.

e) if you are asked to implement a similar program, which of the solutions would you reuse?

For problem A I would choose first method as it allow to store data in human readable form so that is more readable at all.

For problem B I would pick third method because using filters I can implement different logic in separate modules.
