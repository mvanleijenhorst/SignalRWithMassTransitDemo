# SignalRWithMassTransitDemo

Simple demo of using SignalR with MassTransit to send messages to clients.
There is a chat page with SignalR and a MassTransit consumer that sends messages to the chat page.
The MassTransit publish the messsage with a API call.

Chat Page: http://localhost:<port>/chat
API: http://localhost:<port>/api/chat