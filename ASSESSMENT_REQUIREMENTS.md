# Backend Engineering Assessment - Pre-Interview Guide

Welcome! We're looking forward to your upcoming technical interview. This document will help you prepare so you can focus on what matters during the session: writing great code.

> Estimated reading time: 5-10 minutes

---

## 1. Overview

This is a **live coding assessment** lasting **90 minutes**. You'll be given a specific feature to build using a pre-configured boilerplate that follows Clean Architecture with Domain-Driven Design principles.

The goal is to assess your software engineering skills, decision-making, and problem-solving approach. There are no trick questions or hidden gotchas — we want to see how you work through a realistic backend task.

Work in whatever way feels most natural and productive to you.

---

## 2. What You Need to Do Before the Interview

### Setup Requirements

Please complete these steps **before your interview day**:

1. **Clone the repository**

   ```bash
   git clone <repository-url>
   cd backend-assessment
   ```

2. **Ensure Docker Desktop is installed and running**

3. **Start the environment**

   ```bash
   docker compose up
   ```

4. **Verify everything works** by accessing:

   | Service             | URL                                                              | Expected Result                               |
   | ------------------- | ---------------------------------------------------------------- | --------------------------------------------- |
   | Swagger UI          | [http://localhost:8080/swagger](http://localhost:8080/swagger)   | Interactive API documentation page            |
   | Hangfire Dashboard  | [http://localhost:8080/hangfire](http://localhost:8080/hangfire) | Job dashboard with no errors                  |
   | RabbitMQ Management | [http://localhost:15672](http://localhost:15672)                 | Login page (user: `guest`, password: `guest`) |

5. **If you encounter issues**, consult the Troubleshooting section in the README. If problems persist, reach out to **kennedy@lenkie.com** at least **24 hours before your interview** so we can help resolve them.

### Familiarize Yourself with the Stack

Take some time to review the codebase and the concepts it uses:

- Read through **README.md** for the architecture overview and tech stack details
- Browse through the boilerplate code to understand the project structure and how the layers connect
- Note that all method bodies throw `NotImplementedException` — this is intentional and part of the assessment design

If you're unfamiliar with any of the following, we recommend reviewing them beforehand:

- Clean Architecture / Onion Architecture
- CQRS pattern with MediatR
- Domain-Driven Design (DDD) — entities, value objects, domain events
- Repository pattern
- Message-based architecture (publish/subscribe)
- Background job scheduling

Links to relevant documentation are provided in the README.

---

## 3. What to Expect During the Interview

### Interview Format

- **90 minute** live coding session
- You'll receive a specific feature to implement using the boilerplate
- You'll **share your screen** while coding
- You can use whatever tools and resources you normally use when coding
- After coding, there will be a **brief discussion** about your implementation choices

### What We're Assessing

- Your understanding of backend engineering concepts
- Your decision-making around technical trade-offs
- Your ability to explain and defend your implementation choices
- Your testing approach and code quality
- How you approach problem-solving when faced with ambiguity

### What You Can Use

- Any tools or resources you typically use when developing
- Your own IDE, extensions, and developer tools
- Official documentation for any technology in the stack
- Online resources (Stack Overflow, blog posts, etc.)

---

## 4. Technical Capabilities

During the assessment, you'll have the opportunity to demonstrate your ability to:

- Work with databases for both read and write operations
- Publish and consume events using message-based architecture
- Schedule and execute background jobs
- Write effective unit tests
- Design well-structured API endpoints
- Implement structured logging for observability
- Handle errors and edge cases gracefully
- Reason about authentication and authorization concepts

You won't necessarily need to cover all of these — the specific feature will determine which areas are relevant.

---

## 5. Tips for Success

- **Ensure your setup is reliable** — test your development machine and internet connection before the interview
- **Think out loud** — we want to understand your thought process, not just see the final result
- **Ask clarifying questions** — if requirements are ambiguous, ask. This is a sign of good engineering practice, not a weakness
- **Focus on working code first** — get something functional before optimizing
- **Be prepared to explain your choices** — there's often no single right answer, but we want to hear your reasoning

---

## 6. Questions?

If you have questions about the assessment or run into technical setup issues, please contact **kennedy@lenkie.com**.

We ask that you reach out **at least 24 hours before your interview** if you're having trouble getting the environment running, so we have time to help.

Good luck with your preparation — we're looking forward to seeing your work!

---

## Pre-Interview Checklist

Before your interview day, make sure you've completed the following:

- [ ] Repository cloned
- [ ] Docker environment running successfully
- [ ] Swagger UI, Hangfire dashboard, and RabbitMQ management accessible
- [ ] Reviewed architecture documentation in the README
- [ ] Familiarized yourself with any unfamiliar concepts
- [ ] Development environment ready (IDE, extensions, tools)
