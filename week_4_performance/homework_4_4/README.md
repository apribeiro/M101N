# Homework 4.4

### Goal

Import the sysprofile.json file with the following command:
```sh
mongoimport -d m101 -c profile < sysprofile.json
```
Now query the profile data, looking for all queries to the students collection in the database school2, sorted in order of decreasing latency. What is the latency of the longest running operation to the collection, in milliseconds?

### Solution

```sh
> db.profile.find({}, {millis: 1}).sort({millis: -1}).limit(1)
```
**millis = 15820**
