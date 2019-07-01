import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { apiCall } from '../apiUtils';
import { Card, CardBody, CardTitle, CardText, Button } from 'reactstrap';

const BlogCard = (props) => {
  const blog = props.blog;
  return (
    <Card>
      <CardBody>
        <CardTitle>{blog.name}</CardTitle>
        <CardText>{blog.description}</CardText>
        <Button tag={Link} to={`/blog/${blog.id}`}>Read Now!</Button>
      </CardBody>
    </Card>
  );
};

export class Home extends Component {
  static displayName = Home.name;

  state = {
    blogs: [],
  };

  componentDidMount() {
    apiCall('/api/blogs').then((blogs) => {
      this.setState({
        blogs: blogs,
      });
    });
  }

  render() {
    const { blogs } = this.state;
    return (
      <React.Fragment>
        {blogs.map((b, i) => (
          <BlogCard blog={b} key={i} />
        ))}
      </React.Fragment>
    );
  }
}
