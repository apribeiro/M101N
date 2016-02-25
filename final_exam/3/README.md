# Final Exam: Question 3

### Goal

In this problem you will update a document in the Enron dataset (which can be found here) to illustrate your mastery of updating documents from the shell.

Please add the email address "mrpotatohead@mongodb.com" to the list of addresses in the "headers.To" array for the document with "headers.Message-ID" of "<8147308.1075851042335.JavaMail.evans@thyme>".

After you have completed that task run the final3-validate-mongo-shell.js to get the validation code:
```sh
mongo final3-validate-mongo-shell.js
```
The validation script assumes that it is connecting to a simple mongo instance on the standard port on localhost.

### Solution

```sh
> db.messages.update(
	{ "headers.Message-ID": "<8147308.1075851042335.JavaMail.evans@thyme>" },
	{ $addToSet: { "headers.To": "mrpotatohead@mongodb.com" } })
```
**Answer = vOnRg05kwcqyEFSve96R**
