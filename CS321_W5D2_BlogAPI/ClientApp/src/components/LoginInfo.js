import React, { Component } from 'react';

export class LoginInfo extends Component {
  static displayName = LoginInfo.name;

  render() {
    const { loggedIn, email } = this.props;
    return (
      <div>
        <h3 className="text-primary" style={{ textAlign: 'center' }}>
          {loggedIn ? 'Logged in as ' + email : 'You are not logged in.'}
        </h3>
      </div>
    );
  }
}
