function How() {
    Swal.fire({
        html:
            '<div class="align-left">' +
            '<h3><u>How to Use the Website</u></h3>' +
            '<ul>' +
            '<li>To login choose any account from the list of accounts below.</li>' +
            '<li>Admin users can register new employee and admin accounts.</li>' +
            '<li>Users can add items to the cart and place orders.</li>' +
            '<li>In order to place an order and make payments, you can use any test credit card number supported by stripe.' +
            '<ul>' +
            '<li>Test credit card account 4242 4242 4242 4242, any valid date , 424 CVV.</li>' +
            '</ul>' +
            '<li>Once the order is placed, you can login as the Admin User and Manage orders and see the flow of application.</li>' +
            '<li>Menu definitions</li>' +
            '<ul>' +
            '<li>Content Management &nbsp; - &nbsp; Product, book cover type, & book category management.</li>' +
            '<li>Company &nbsp; - &nbsp; Customer company affiliation management.</li>' +
            '<li>User &nbsp; - &nbsp; Customer & user account management.</li>' +
            '<li>Order Management &nbsp; - &nbsp; Customer orders & order list.</li>' +
            '</ul>' +
            '</li>' +

            '</br>' +

            '<h4><u>Login/User Management Overview:</u></h4>' +
            '<ul>' +
            '<li>Please use login credentials below. Each login would have different roles. See role definitions below in parenthesis.'+
            '<ul>' +
            '<li>Admin User (Has access to everything) &nbsp; - &nbsp; <i style="color:dodgerblue">administrator@bookstore.com (Password: Admin123$)</i></li>' +
            '<li><u>For the rest of the accounts below password is &nbsp; - &nbsp; <i style="color:dodgerblue">(User123$)</i></u></li>' +
            '<li>Employee User (Does not have access to Content Management) &nbsp; - &nbsp; <i style="color:dodgerblue">employee@bookstore.com</i></li>' +
            '<li>Individual Customer User (Can only place orders and only has access to its own order list)&nbsp; - &nbsp; <i style="color:dodgerblue">individual@booskstore.com</i></li>' +
            '<li>Authorized Company Customer User&nbsp; - &nbsp; <i style="color:dodgerblue">authcompany@bookstore.com</i></li>' +
            '<li>Non Authorized Company Customer User&nbsp; - &nbsp; <i style="color:dodgerblue">nonauthcompany@bookstore.com</i></li>' +
            '</ul>' +
            '</li>' +
            '<li>To test account creation, please login as the Admin then click on the User Menu to create an account. &nbsp;</li>' +

            '</ul>' +
            '</ul>' +
            '</div>',


        showCloseButton: true,
        showCancelButton: true,
        focusConfirm: false,
        customClass: 'swal-wide',
        confirmButtonText:
            '<i class="fa fa-thumbs-up"></i>',
        confirmButtonAriaLabel: 'Thumbs up',
        cancelButtonText:
            '<i class="fa fa-thumbs-down"></i>',
        cancelButtonAriaLabel: 'Thumbs down'
    });


}

function Contact() {
    Swal.fire({
        html:
            '<div class="align-left">' +
                '<h3><u>How to get in touch with me</u></h3>' +
                '</br>' +
                '<h4>Developer: Brian Naoe</h4>' +
                '<a href="mailto:mybpn.projects@gmail.com = Feedback&body = Message">' +
                'Send feedback to: Mybpn.Projects@gmail.com' +
                '</a>' +
                '</div>' +
                '<div class="align-left">' +
                '<a href="https://www.linkedin.com/in/brian-paulo-naoe">' +
                'My Linkedin profile' +
                '</a>' +
                '</div>' +
                '<div class="align-left">' +
                '</br>' +
                '</br>' +
                '<h4><u>Github repositories</u></h4>' +
                '<a href="https://github.com/bnaoe">' +
                'Github profile' +
                '</a>' +
                '</br>' +
                '<h4><u>Github repository for this project</u></h4>' +
                '<a href="https://github.com/bnaoe/OnlineBookStore">' +
                'Github Online Bookstore' +
                '</a>' +

                '</div>',
        showCloseButton: true,
        showCancelButton: true,
        focusConfirm: false,
        customClass: 'swal-wide',
        confirmButtonText:
            '<i class="fa fa-thumbs-up"></i>',
        confirmButtonAriaLabel: 'Thumbs up',
        cancelButtonText:
            '<i class="fa fa-thumbs-down"></i>',
        cancelButtonAriaLabel: 'Thumbs down'
    });


}