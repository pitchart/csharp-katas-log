# TDD as if you Meant it

## [The Rules](https://cumulative-hypotheses.org/2011/08/30/tdd-as-if-you-meant-it/)

1. Write exactly one new test, the smallest test you can that seems to point in the direction of a solution
2. See it fail
3. Make the test from (1) pass by writing the least implementation code you can in the test method.
4. Refactor to remove duplication, and otherwise as required to improve the design. Be strict about using these moves:
    1. you want a new method—wait until refactoring time, then… create new (non-test) methods by doing one of these, and in no other way:
        1. preferred: do Extract Method on implementation code created as per (3) to create a new method in the test class, or
        2. if you must: move implementation code as per (3) into an existing implementation method
    2. you want a new class—wait until refactoring time, then… create non-test classes to provide a destination for a Move Method and for no other reason
        1. populate implementation classes with methods by doing Move Method, and no other way
