

/*

Key pieces to understand
* Async code can be used for both I/O-bound and CPU-bound code, but differently for each scenario.
* Async code uses Task<T> and Task, which are constructs used to model work being done in the background.
* The async keyword turns a method into an async method, which allows you to use the await keyword in its body.
* When the await keyword is applied, it suspends the calling method and yields control back to its caller until the awaited task is complete.
* await can only be used inside an async method.

IF YOU'RE WAITING FOR I/O-BOUND WORK then use async and await (do not use Task.Run)
IF YOU'RE WAITING FOR CPU-BOUND WORK then use async and await and spawn the work on another tread with Task.Run. Possibly also 
use concurrency bia the task parallel library


 */

using AsyncBreakfast;

//Sync.Main(null);


//await Async3.Main(null);

Async3.Main(null).Wait();