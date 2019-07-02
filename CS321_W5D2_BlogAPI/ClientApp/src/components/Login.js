import React from 'react';
import { Button, Form, FormGroup, Label, Input } from 'reactstrap';
import { apiCall } from '../apiUtils';

export class Login extends React.Component {
  state = {
    loginModel: {},
  };

  handleClick = (e) => {
    const { loginModel } = this.state;
    console.log('loginmodel', loginModel);
    e.preventDefault();
    apiCall(`/api/auth/login`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(loginModel),
    }).then((data) => {
      localStorage.setItem('token', data.token);
      console.log('login', data);
    });
  };

  handleChange = (e) => {
    var loginModel = { ...this.state.loginModel };
    loginModel[e.target.name] = e.target.value;
    this.setState({ loginModel });
  };

  render() {
    return (
      <Form>
        <FormGroup>
          <Label for="email">Email</Label>
          <Input
            type="email"
            name="email"
            id="email"
            placeholder="email"
            onChange={this.handleChange}
          />
        </FormGroup>
        <FormGroup>
          <Label for="password">Password</Label>
          <Input
            type="password"
            name="password"
            id="password"
            placeholder="password"
            onChange={this.handleChange}
          />
        </FormGroup>
        <Button onClick={this.handleClick}>Login</Button>
        <Button>Cancel</Button>
      </Form>
    );
  }
}
