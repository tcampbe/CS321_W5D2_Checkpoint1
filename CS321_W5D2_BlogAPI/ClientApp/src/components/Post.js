import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { apiCall } from '../apiUtils';
import { Card, CardBody, CardTitle, CardText, Button } from 'reactstrap';

export class Post extends Component {
  static displayName = Post.name;

  state = {
    post: {},
    comments: []
  };

  componentDidMount() {
    const { blogId, postId } = this.props.match.params;
    apiCall(`/api/blogs/${blogId}/posts/${postId}`)
    .then((post) => {
      this.setState({
        post: post
      });
    });
  }

  render() {
    const { post, comments } = this.state;
    console.log('post render');
    return (
      <React.Fragment>
        <h1>{post.title}</h1>
        <div dangerouslySetInnerHTML={{ __html: post.content }} />
      </React.Fragment>
    );
  }
}
