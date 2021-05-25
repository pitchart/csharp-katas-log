# Command Query Separation

## The Rules

The fundamental idea is that we should divide an object's methods into two sharply separated categories:

- **Queries:** Return a result and do not change the observable state of the system (are free of side effects).
- **Commands:** Change the state of a system but do not return a value.

## More

- https://www.martinfowler.com/bliki/CommandQuerySeparation.html
