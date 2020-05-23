# FiboBanking
Matt Parker's Fibonacci Bank Account http://think-maths.co.uk/maths-puzzles (#6) solution program...

Given the "adding the last two", I was immediately convinced to find a reference to Fibonacci, and it didn't take long to find it.

## Basic assumptions

Find the target by going in reverse, starting at the 1000000 mark.
Target is EXACTLY 1000000, so the previous two must add up to it.  Xn = X(n-1) + X(n-2)

Since the previous one is in part made up of the second to last amount, it must be larger:  X(n-1) > X(n-2)

In order to achieve X with the above rules, X(n-1) must be larger than X / 2, or in our case, 500k.

We are at some basic sanity rules to validate our solution:

```
X(n-1) > 500000
X(n-2) < 500000
X(n-1)+X(n-2) = 1000000
or  X(n-2) = 1000000 - X(n-1)
```
## finding a proper formula

Let's call the current (also target) amount X0, and every day before that X1, X2 and so on (simplified version of X(n-1), X(n-2)...)

```
X0 = X1 + X2
```

and since X1 came from X2 and X3 (the days before that)

```
X1 = X2 + X3
```

and so on...

We can thus conclude, numbering the days in reverse:

```
1: X1 = X2 + X3
2: X2 = X3 + X4
3: X3 = X4 + X5
4: X4 = X5 + X6
5: X5 = X6 + X7
...etc...
```

Substituting for the first few entries gives us:
```
2: X1 = X3 + X4 + X3
3: X1 = X4 + X5 + X4 + X4 + X5
4: X1 = x5 + x6 + x5 + x5 + x6 + x5 + x6 + x5
5: X1 = x6 + X7 + x6 + x6 + X7 + x6 + X7 + x6 + x6+ X7 + x6 + x6 + X7
...etc...
```

Simplification of these gives us:
```
2: 2 * X3 + 1 * X4
3: 3 * X4 + 2 * X5
4: 5 * X4 + 3 * x6
5: 8 * X6 + 5 * X7
```

The co-efficients of every amount on day n are follwoing the fibonacci sequence. We can thus conclude:

We are looking for two consecutive fibonacci numbers f1 and f2 so that:

```
X = f1 * a + f2 * b
```

With X = 1000000 and both a and b are integer numbers, with both f1 and f2 as high as possible (longest run)
This formula assumes that both a and b are arbitrary, but in our case, day 2 is already including day 1 plus the new deposit.
Assuming that zero is not a valid initial deposit and that thus day 2 balance must be larger than day 1.

The upper limit of our search thus is the two fibonacci numbers that preceed one that is larger than 1M, becaues f1*1+f2*1 > 1M is too large.

## solving

### Let's call it a "Parker Solution"...
...the numbers here have an error, due to a wrong formula... I knew I should refrain from swapping things in my head without proper notes.

Since this is a formula with one solution but two unknowns, a simple direct computation seems impossible.

Thus, after writing a program to find fibonacci pairs until the upper limit and then trying out different integer values for a and b in reverse order, reveals that the highest f1/f2 combination that produces exactly 1000000 as a result is 610 and 987, with a and b as 442 and 740. 

Since b is including a, for the submission is should be 442 and 740-442 and that reaches 1000000 on day 17.

```
Day 1: 442
Day 2 : 740
Day 3 : 1182
Day 4 : 1922
Day 5 : 3104
Day 6 : 5026
Day 7 : 8130
Day 8 : 13156
Day 9 : 21286
Day 10 : 34442
Day 11 : 55728
Day 12 : 90170
Day 13 : 145898
Day 14 : 236068
Day 15 : 381966
Day 16 : 618034
Day 17 : 1000000
Solution: deposit 442 and 298, reach 1000000 in 17 days
```
### Here's the real version, with proper numbers

154 and 144 for the initial amounts:

```
Day 1: 154
Day 2 : 144
Day 3 : 298
Day 4 : 442
Day 5 : 740
Day 6 : 1182
Day 7 : 1922
Day 8 : 3104
Day 9 : 5026
Day 10 : 8130
Day 11 : 13156
Day 12 : 21286
Day 13 : 34442
Day 14 : 55728
Day 15 : 90170
Day 16 : 145898
Day 17 : 236068
Day 18 : 381966
Day 19 : 618034
Day 20 : 1000000

Solution: deposit 154 and -10, reach 1000000 in 20 days
```

So, my solution now yields 154 and -10 with 20 days to reach 1M... D'Oh.
