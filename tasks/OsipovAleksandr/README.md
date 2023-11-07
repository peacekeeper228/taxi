# Nothing useful
## How to launch
### Second
main.py implements third method (pipes) of second task (8 queens)
To launch - just run file, no need to change anything, in pipes the first module sends data every 5 seconds 10 times, after it it stops. All other modules works in a moment data arrives at pipe port
### First
main1.py implements second method (shared data) of first task (KWIC)
To launch with different params change it in input function
## Some notes
Here different programs are replaced with functions because of small program size:)
## Analysis of methods
a) In which case it is easier to change the implementation algorithm in each of the modules? 
Because of the size of the program it is easy to change everywhere, but in large program it depends on how the division of subsystems was conducted  
b) in which solution it is easier (= seemingly less effort) to change data representation
Based on proggraming language and its typing (not sure here, russian is типизация). On python, for example, no need to describe the transferred data, so it is just about changing function logics  
c) in which solution it is easier to add additional functions to the modules
With shared data, just add and then call it, in pipes, for example, you need to change thr pipe of data:)  
d) which solution is seemingly more performant?
With pipes, but it depends on how it is build on a particular language, but not in cause of extra data coping  
e) if you are asked to implement a similar program, which of the solutions would you reuse?
With shared data, because it is the simplest in case of implementation  
