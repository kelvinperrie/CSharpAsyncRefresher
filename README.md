# CSharpAsyncRefresher

Key pieces to understand
* Async code can be used for both I/O-bound and CPU-bound code, but differently for each scenario.
* Async code uses Task\<T> and Task, which are constructs used to model work being done in the background.
* The async keyword turns a method into an async method, which allows you to use the await keyword in its body. IT DOES NOTHING ELSE! It does no magic.
* When the await keyword is applied, it suspends the calling method and yields control back to its caller until the awaited task is complete.
(so remember this will go up the chain kind of unexpectedly - the await doesn't just mean we will sit and wait for the statement to complete, we totally jump out of that async method. If you don't wait somewhere up the chain then the program can potentially exit before the code being awaited is finished. I know right, what kind of mickey mouse type feature is this.)
* await can only be used inside an async method. So enjoy making everything async all the way to the top my friend.

IF YOU'RE WAITING FOR I/O-BOUND WORK then use async and await (do not use Task.Run)

IF YOU'RE WAITING FOR CPU-BOUND WORK then use async and await and spawn the work on another tread with Task.Run. Possibly also 
use concurrency bia the task parallel library
