# Final Exam: Question 5

### Goal

Suppose your have a collection stuff which has the _id index,
```sh
{
    "v" : 1,
    "key" : {
      "_id" : 1
    },
    "ns" : "test.stuff",
    "name" : "_id_"
}
```
and one or more of the following indexes as well:
```sh
{
    "v" : 1,
    "key" : {
      "_id" : 1
    },
    "ns" : "test.stuff",
    "name" : "_id_"
}
```
```sh
{
    "v" : 1,
    "key" : {
      "a" : 1,
      "b" : 1
    },
    "ns" : "test.stuff",
    "name" : "a_1_b_1"
}
```
```sh
{
    "v" : 1,
    "key" : {
      "a" : 1,
      "c" : 1
    },
    "ns" : "test.stuff",
    "name" : "a_1_c_1"
}
```
```sh
{
    "v" : 1,
    "key" : {
      "c" : 1
    },
    "ns" : "test.stuff",
    "name" : "c_1"
}
```
```sh
{
    "v" : 1,
    "key" : {
      "a" : 1,
      "b" : 1,
      "c" : -1
    },
    "ns" : "test.stuff",
    "name" : "a_1_b_1_c_-1"
}
```
Now suppose you want to run the following query against the collection.
```sh
db.stuff.find({'a':{'$lt':10000}, 'b':{'$gt': 5000}}, {'a':1, 'c':1}).sort({'c':-1})
```
Which of the indexes could be used by MongoDB to assist in answering the query?

### Solution

- c_1
- a_1_b_1
- a_1_c_1
- a_1_b_1_c_-1
