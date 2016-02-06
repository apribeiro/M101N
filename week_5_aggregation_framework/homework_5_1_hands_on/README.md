# Homework 5.1

### Goal

In this assignment you will use the aggregation framework to find the most frequent author of comments on your blog.
Use the aggregation framework to calculate the author with the greatest number of comments.

### Solution

```sh
> db.posts.aggregate([
	{
		$unwind : "$comments"
	},
	{
		$group: {_id: "$comments.author", count: {$sum: 1}}
	},
	{
		$sort: {count: -1}
	},
	{
		$limit: 1
	}
])
```
**Answer = Gisela Levin with 112 comments**
