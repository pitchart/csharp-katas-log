# Diamond

## About this Kata

Alistair Cockburn wrote a blog post about this kata, in response to the Seb Rose kata proposition.

## Problem Description

Given a letter, print a diamond starting with ‘A’ with the supplied letter at the widest point.

For example: print-diamond ‘C’ prints

```
A    A      A         A
    B B    B B       B B
     A    C   C     C   C
           B B     D     D
            A       C   C
                     B B
                      A
```

## The test recycling way

> Decompose the diamond problem into smaller constituent parts
> E.g. for B: "AB" -> "ABB" -> "A\nBB\n" ...

## The TDDist way

> A -> B -> C, easy as do ré mi ?


## The functional way

> With property based testing :)

Focus on results properties and implement from less to more complex 
