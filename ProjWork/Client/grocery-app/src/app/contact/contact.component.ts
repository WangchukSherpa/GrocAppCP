import { Component, OnInit } from '@angular/core';
import emailjs from 'emailjs-com';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    emailjs.init("CAKKghVjqX27vLn1Y");
  }

  onSubmit(e: Event) {
    e.preventDefault();
    const form = e.target as HTMLFormElement;
    const formData = new FormData(form);

    const templateParams = {
      name: formData.get('name'),
      email: formData.get('email'),
      message: formData.get('message')
    };

    emailjs.send('service_xnkykbl', 'template_eeiqpbb', templateParams)
      .then((response) => {
        console.log('SUCCESS!', response.status, response.text);
        alert('Message sent successfully!');
        form.reset();
      }, (error) => {
        console.error('FAILED...', error);
        alert(`Failed to send message. Error: ${error.text}`);
      });
  }
}