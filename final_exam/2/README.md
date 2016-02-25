# Final Exam: Question 2

### Goal

Please use the Enron dataset you imported for the previous problem. For this question you will use the aggregation framework to figure out pairs of people that tend to communicate a lot. To do this, you will need to unwind the To list for each message. 

This problem is a little tricky because a recipient may appear more than once in the To list for a message. You will need to fix that in a stage of the aggregation before doing your grouping and counting of (sender, recipient) pairs. 

Which pair of people have the greatest number of messages in the dataset?

### Solution

```sh
> db.messages.aggregate([
	{ $unwind: "$headers.To" },
	{ $group: {
			_id: {
				_id: "$_id",
				headers_from: "$headers.From"
			},
			headers_to: { $addToSet: "$headers.To" }
		}
	},
	{ $project: {
		_id: "$_id._id",
		headers_from: "$_id.headers_from",
		headers_to: 1
	}},
	{ $unwind: "$headers_to" },
	{ $group: {
		_id: {
			from: "$headers_from",
			to: "$headers_to"
		},
		count: {
			$sum: 1
		}
	}},
	{ $sort: { count: -1 }},
], { allowDiskUse: true })
```
**Answer = susan.mara@enron.com to jeff.dasovich@enron.com (750)**
