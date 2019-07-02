import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { apiCall } from '../apiUtils';
import { Card, CardBody, CardTitle, CardSubtitle, CardText, Button } from 'reactstrap';


export class ApiInfo extends Component {
  static displayName = ApiInfo.name;

  componentDidMount() {
  }

  render() {
    const { apiInfo = {} } = this.props;
    return (
        <div>
            <p>ApiInfo</p>
            {apiInfo.route}
        </div>
    );
  }
}
