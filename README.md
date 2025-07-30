

## 🔧 Custom Development Overview

This project is a customized fork of the original Octagram social media API.

The following features have been added as part of the second-phase development:

- ✅ **Downvote API**  
  A new endpoint has been introduced to allow users to downvote posts.

- ☁️ **AWS SQS Integration**  
  Downvote notifications are now sent asynchronously via Amazon SQS for improved scalability and decoupling.

- 🧪 **Unit & Integration Testing**  
  New unit and integration tests have been implemented, especially for the downvote feature and SQS message flow.

This enhancement improves user interaction tracking and leverages cloud-native messaging to prepare for horizontal scaling.
