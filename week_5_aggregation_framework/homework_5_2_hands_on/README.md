# Homework 5.2

### Goal

Please calculate the average population of cities in California (abbreviation CA) and New York (NY) (taken together) with populations over 25,000.
For this problem, assume that a city name that appears in more than one state represents two separate cities.

Please round the answer to a whole number.<br>
Hint: The answer for CT and NJ (using this data set) is 38177.

Please note:
- Different states might have the same city name.
- A city might have multiple zip codes.

### Solution

```sh
> db.zips.aggregate([
	{
		$group: {_id: {state: "$state", city: "$city"}, pop: {$sum: "$pop"}}
	},
	{
		$match : {pop: {$gt: 25000}, "_id.state": {$in: ["CA", "NY"]}}
	},
	{
		$group: {_id: "", average: {$avg: "$pop"}}
	}
])
```
**Answer &cong; 44805**
