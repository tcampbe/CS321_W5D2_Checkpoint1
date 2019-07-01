import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { apiCall } from '../apiUtils';
import { Card, CardBody, CardTitle, CardSubtitle, CardText, Button } from 'reactstrap';

const PostCard = (props) => {
  const post = props.post;
  return (
    <Card>
      <CardBody>
        <CardTitle>{post.title}</CardTitle>
        <CardSubtitle>{post.datePublished.substring(0, 10)}</CardSubtitle>
        <CardText style={{ overflow: 'hidden', textOverflow: 'ellipsis', height: 50 }}><div dangerouslySetInnerHTML={{ __html: post.content }}/></CardText>
        <Button tag={Link} to={`/blog/${post.blogId}/post/${post.id}`}>Read More...</Button>
      </CardBody>
    </Card>
  );
};

export class Blog extends Component {
  static displayName = Blog.name;

  state = {
    blog: {},
    posts: []
  };

  componentDidMount() {
    const { blogId } = this.props.match.params;
    apiCall(`/api/blogs/${blogId}`)
      .then((blog) => {
        console.log(blog);
        this.setState({
          blog: blog,
        });
      });
    apiCall(`/api/blogs/${blogId}/posts`)
    .then((posts) => {
      this.setState({
        posts: posts
      });
    });
  }

  render() {
    const { blog, posts } = this.state;
    return (
      <React.Fragment>
        <h1>{blog.name}</h1>
        {posts.map((p, i) => (
          <PostCard post={p} key={i} />
        ))}
      </React.Fragment>
    );
  }
}
