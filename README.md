# GoQuick - Fullstack Grocery App

## Overview

Welcome to GoQuick, a fullstack grocery application designed to provide a seamless shopping experience. Built using Angular 18 for the frontend and .NET 8 with C# for the backend, GoQuick offers robust features for managing grocery items, orders, payments, and user authentication. This project showcases modern web development practices, combining a powerful frontend with a scalable backend.

## Tech Stack

- Frontend: Angular 18
- Backend: .NET 8 with C#
- Database: SQL Server (managed with SQL Server Management Studio)
- Authentication: JWT-based authentication
- Payment Integration: Stripe
- Feedback System: EmailJS for contact and feedback
- API Communication: RESTful API with JSON data format
- Build Tools: Node.js, Angular CLI, .NET CLI

## Features

1. **User Authentication**

   - JWT-based authentication: Secure login and token management.
   - Registration and Login: New users can register and existing users can log in securely.
   - Role-based Access Control: Different features for regular users and admins.

2. **Product Management**

   - Browse Products: Users can browse through a list of grocery items.
   - Product Details: View detailed information for each product including name, price, description, and image.

3. **Shopping Basket**

   - Add to Basket: Users can add items to their shopping basket.
   - Update Basket: Adjust quantities of items in the basket.
   - Remove Items: Option to remove items from the basket.
   - Persistent Basket: The shopping basket persists between sessions.

4. **Order and Checkout**

   - Order Creation: Users can place an order after reviewing their basket.
   - Delivery Methods: Choose from different delivery options.
   - Payment Integration: Payments are securely processed using Stripe for a seamless checkout experience.

5. **Responsive Design**

   - Optimized for both mobile and desktop, offering a great user experience across devices.

6. **Real-time Updates**

   - Products and basket contents are updated in real-time using efficient API calls.
   - Concurrency control for basket updates to avoid conflicts.

7. **Feedback/Contact Us**
   - Integrated with EmailJS to provide a simple and efficient way for users to send feedback or contact support directly via email.

## Setup Instructions

### Backend (.NET 8 + C#)

1. Install the .NET 8 SDK from the official .NET website.
2. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/goquick-backend.git
   ```
3. Navigate to the backend project directory:
   ```bash
   cd goquick-backend
   ```
4. Restore the required packages:
   ```bash
   dotnet restore
   ```
5. Update the `appsettings.json` file with your database connection string and Stripe API keys.
6. Run the project:
   ```bash
   dotnet run
   ```

### Frontend (Angular 18)

1. Install Node.js and Angular CLI if not already installed:
   ```bash
   npm install -g @angular/cli
   ```
2. Clone the frontend repository:
   ```bash
   git clone https://github.com/yourusername/goquick-frontend.git
   ```
3. Navigate to the frontend project directory:
   ```bash
   cd goquick-frontend
   ```
4. Install dependencies:
   ```bash
   npm install
   ```
5. Configure EmailJS for the contact form in the frontend.
6. Start the Angular development server:
   ```bash
   ng serve
   ```
7. Open a browser and go to `http://localhost:4200/` to view the app.

### Database

1. Set up a SQL Server database using SQL Server Management Studio.
2. Update the connection string in the `appsettings.json` file.
3. Run database migrations (if any) using Entity Framework.

### Payment Integration (Stripe)

1. Set up a Stripe account at https://stripe.com/.
2. Retrieve your Stripe API keys and add them to the backend configuration in `appsettings.json`.

## API Documentation

You can find the full API documentation at `https://localhost:7275/swagger/index.html` (for development).

## Contribution Guidelines

We welcome contributions from the community! Please follow these steps to contribute:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature-branch`).
3. Commit your changes (`git commit -m 'Add new feature'`).
4. Push to the branch (`git push origin feature-branch`).
5. Create a pull request.

## License

This project is licensed under the MIT License. See the LICENSE file for more details.

## Contact

If you have any questions or feedback, feel free to reach out to us at support@goquickapp.com.
