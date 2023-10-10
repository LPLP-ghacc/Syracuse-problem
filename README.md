# Syracuse problem

The Collatz conjecture, also known as the 3n + 1 problem or the Collatz problem, is a mathematical problem that has remained unsolved since its inception in the early 20th century. The conjecture is formulated as follows:

Start with any positive integer n.
If n is even, divide it by 2 (n/2).
If n is odd, multiply it by 3 and add 1 (3n + 1).
Repeat steps 2 and 3 until you get the number 1.
The Collatz Hypothesis states that starting with any positive integer n, you will always eventually reach the number 1. This statement has not yet been proved or disproved, and it remains an open problem in mathematics.

Although Collatz's hypothesis may seem simple, it is of great interest in the world of mathematics because of its complexity and ambiguity. For some numbers, the sequence of operations can be quite long before the number 1 is reached, but there are no known numbers yet for which it has been proven that they do not satisfy this hypothesis.

The study of the Collatz conjecture remains an active area of mathematical research, and scientists continue to search for deeper properties of this sequence of numbers that might help in its solution.

![image](https://github.com/LPLP-ghacc/Syracuse-problem/assets/53939350/ba526082-f4c3-49cb-af1f-f0d3224237cc)

[PROJECT TheCollatzProblem] <a>https://github.com/LPLP-ghacc/Syracuse-problem/tree/master/TheCollatzProblem</a>

The provided code is a C# console application that performs calculations related to the "3x + 1 problem" using both CPU and GPU processing. This problem involves repeatedly applying a mathematical function to a number until it reaches the value of 1. The code finds and tracks the maximum value obtained during this process for various initial numbers.

Here's an overview of the key components of the code:

The Main method is the entry point of the program, which calls the GetNumAsync method to perform the calculations asynchronously.

The GetNumAsync method initializes a variable maxNumber to store the maximum value encountered during the calculations. It then iterates through a loop with a very large number of iterations (up to int.MaxValue). In each iteration, it generates a sequence of numbers using the GetNewValuesAsync method and checks if any of these values is greater than the current maxNumber. If a greater value is found, it updates maxNumber and prints the number and the new maximum.

The GetNewValues method performs similar calculations as GetNewValuesAsync but uses GPU processing via the CUDA framework. It initializes a list to store the values, creates a CUDA context, and copies data between the CPU and GPU memory to perform the calculations.

The GetNewValuesAsync method is an asynchronous method that calculates the sequence of numbers for a given initial number and a specified number of steps. It returns a list of these values.

Key Features of the Code
Asynchronous Programming: The code uses asynchronous methods (async and await) to avoid blocking the main thread during long-running calculations.

Parallel Processing: It calculates values for multiple initial numbers in parallel by using asynchronous operations. This can potentially improve performance on systems with multiple cores.

GPU Processing: The code demonstrates the use of GPU processing through the CUDA framework for calculating sequences of numbers. This can significantly speed up calculations for large numbers of iterations.

Dynamic Programming: The code uses dynamic programming to generate sequences of numbers based on the "3x + 1 problem," where each number is modified based on a mathematical function.

Result Tracking: It keeps track of and prints the maximum value encountered during the calculations.
