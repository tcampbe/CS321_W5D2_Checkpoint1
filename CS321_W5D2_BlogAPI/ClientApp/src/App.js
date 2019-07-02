import './App.css'
import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Blog } from './components/Blog';
import { Post } from './components/Post';
import { Register } from './components/Register';
import { Login } from './components/Login';
import { apiCall } from './apiUtils';

export default class App extends Component {
  static displayName = App.name;

  state = {
    loggedIn: false,
  }

  logIn = (loginModel) => {
    apiCall(`/api/auth/login`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(loginModel),
    }).then((res) => {
      localStorage.setItem('token', res.data.token);
      this.setState({
        loggedIn: true
      });
    });
  }

  logOut = () => {
    localStorage.removeItem('token');
    this.setState({
      loggedIn: false
    });
  }

  register = () => {

  }

  componentDidMount() {
    const token = localStorage.getItem('token');
    this.setState({
      loggedIn: !!token
    });
  }

  render() {
    const { loggedIn } = this.state;
    return (
      <Layout loggedIn={loggedIn} logOut={this.logOut}>
        <Route
          exact
          path="/"
          component={Home}
        />
        <Route
          exact
          path="/blog/:blogId/post/:postId"
          component={Post}
        />
        <Route
          exact
          path="/blog/:blogId"
          component={Blog}
        />
        <Route
          exact
          path="/register"
          component={Register}
        />
        <Route
          exact
          path="/login"
          component={Login}
        />
      </Layout>
    );
  }
}
