import './App.css'
import React, { Component } from 'react';
import { withRouter } from 'react-router-dom'
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Blog } from './components/Blog';
import { Post } from './components/Post';
import { Register } from './components/Register';
import Login from './components/Login';
import { apiCall } from './apiUtils';

class App extends Component {
  static displayName = App.name;

  state = {
    loggedIn: false,
  }

  logIn = (loginModel) => {
    console.log('logIn');
    const { history } = this.props;
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
      history.push('/');
    });
  }

  logOut = () => {
    localStorage.removeItem('token');
    this.setState({
      loggedIn: false
    });
  }

  register = (registrationModel) => {
    const { history } = this.props;
    apiCall(`/api/auth/register`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(registrationModel),
    }).then((res) => {
      history.push('/login');
    });
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
          component={() => <Register register={this.register} />}
        />
        <Route
          exact
          path="/login"
          component={() => <Login logIn={this.logIn}/>}
        />
      </Layout>
    );
  }
}
export default withRouter(App);