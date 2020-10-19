# JM Programming Exercise

This repository forms part of an interview process whereby the applicant needs to work to a particular brief, provided by the company.
The brief is provided below for posterity, after which follows my input.
<br/> <br/>

>## Brief
>In order to evaluate your programming skills, we ask you to solve the following
>task. The task is solved in a programming language of your choice.
>We ask you to deliver the solution in the same quality as you would provide a
>delivery to a customer. You may not use other people’s code or code libraries
>to resolve the task. That is, the solution can only contain references to the
>standard libraries of your language, as well as any third party libraries for unit
>tests.
>We are interested in your competence in several areas, including:
>* Your chosen language
>* Programming paradigms related to your selection of programming language
>* Software design and architecture
>* Tests
>* User interfaces
>
>
>Your solution to the programming assignment will form the basis of the conversation during the technical interview. Highlight what you are good at. If you
>feel certain parts could have been resolved better if you had more time, then
>comment on that too.
>From the time you receive the assignment, you usually have one week to submit
>your solution. The solution can be submitted via for example GitHub or as a
>zip file.
>___
>###### Task: Robot programming
>Your task is to program the controller to a robot as a web-server. It’s a simple
>robot that can walk around in a room where the floor is represented as a number
>of fields in a wire mesh. Input is first two numbers, which tells the robot how
>big the room is:
>* 5 7
>
>Which means that the room is 5 fields wide and is 7 fields deep.
>
>The size of the room follows two digits and one letter indicating the starting
>position of the robot and its orientation in space. For example:
>* 3 3 N
>
>Which means that the robot is in field (3, 3) and faces north. Subsequently, the
>robot receives a number of navigation commands in the form of characters. The
>following commands shall be implemented:
>
>* L Turn left
>* R Turn right
>* F Walk forward
>
>Example:
>LFFRFRFRFF
>After the last command is received, the robot must report which field it is in
>and what direction it is facing.
>```
>Example:
>5 5
>1 2 N
>RFRFFRFRF
>Report: 1 3 N
>```
>```
>5 5
>0 0 E
>RFLFFLRF
>Report: 3 1 E
>```
<br>

## Robustness and Assumptions

Some effort has been made to ensure the code is relatively robust, without going too 
overboard on features or making unreasonable assumptions:

* Report displays `Invalid data` if the first input contains invalid data (i.e. not 2 ints)
* The Robot ignores any invalid navigation commands (e.g. `B`, `Forward`)
* If a command would make the Robot pass into a wall of the room, the Robot will ignore this
command.

In general, I have tried to find a "middle-ground" in terms of abstractions. Though
abstractions can certainly help in terms of extensibility, for a small application like
this, one could easily add unnecessary complexity.

## Testing

I believe I have written enough test cases to cover the majority of possible bugs (with the exception of 
the point described in the 'Improvements and Extensibility' section below), without
writing tests that would be of little value.

## Improvements and Extensibility

Though, as mentioned above, effort has been made to ensure the code is reliable, there are still a
few improvements I would like to make if time allowed and the scope were more narrowly
defined:

* At the moment the report will be inaccurate if initial room specs are negative ints. 
This could reasonably be solved by making use of unsigned int (uint) and catching a 
`System.OverflowException`.

* The Robot reports inaccurately if its starting position is outside the bounds of the
room.

The solution could be more extensible, though of course it would be difficult to
address every possible eventuality. Given more time I would give more thought to the questions
below:

> What if the room were a different shape
	
> How easy would it be to implement more movement options (e.g. diagonal movement,
backwards movement)?

> How easy would it be to implement new commands (e.g `quit` or `jump`)?
	
> What if the data were in json format? This is partially solved with the use of the 
>`IData` interface and `InputBase` base class, but perhaps more thought would yield a
better approach.

> What if we wanted more data in the report (e.g `numberOfSteps` or `runTime`)?

## Further Work
I have previously completed a variation of this exercise for another process,
which can be found [here](https://github.com/1337jazz/SM-Programming-Exercise).
