import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Blog } from './components/Blog';
import { Post } from './components/Post';
import { Register } from './components/Register';
import { Login } from './components/Login';

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Route
          exact
          path="/"
          component={() => <Home />}
        />
        {/* <Route
          path="/counter"
          component={() => <ApiInfoContainer comonent={Counter} />}
        /> */}
        {/* <Route path="/fetch-data" component={FetchData} /> */}
        <Route
          exact
          path="/blog/:blogId/post/:postId"
          component={() => <Post />}
        />
        <Route
          exact
          path="/blog/:blogId"
          component={() => <Blog />}
        />
        <Route
          exact
          path="/register"
          component={() => <Register />}
        />
        <Route
          exact
          path="/login"
          component={() => <Login />}
        />
      </Layout>
    );
  }
}
