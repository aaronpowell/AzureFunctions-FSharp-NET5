module Run

open Microsoft.Extensions.Logging
open Microsoft.Extensions.Configuration
open Microsoft.Azure.Functions.Worker.Http
open Microsoft.Azure.Functions.Worker
open FSharp.Control.Tasks

[<Function "Example">]
let run ([<HttpTrigger "GET">] req: HttpRequestData, logger: ILogger) =
    task {
        let response = req.CreateResponse()

        do!
            response
                .WriteAsJsonAsync({| Response = "Hello World!" |})
                .AsTask()

        return response
    }
