# Homework 2.1

### Goal

Find all exam scores greater than or equal to 65, and sort those scores from lowest to highest.
What is the student_id of the lowest exam score above 65?

### Solution

```sh
> db.grades.find({score: {$gte: 65}}).sort({score: 1}).limit(1)
```
**student_id = 22**
