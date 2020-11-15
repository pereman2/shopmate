import '../assets/css/App.css';
import React from 'react';
import TopBar from './TopBar';
import LeftPanel from './LeftPanel';
import RightPanel from './RightPanel';
import Nav from './Nav';
import Login from './Login';
import UserDetails from './UserDetails';

export const dataBaseURL = 'https://localhost:5001';

class App extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      'selectedPanel': 'cart',
      'results': [],
      'lastPanel': '',
      'login': false
    };
    this.changeProductResults = this.changeProductResults.bind(this);
    this.goToLastState = this.goToLastState.bind(this);
  }

  changeLastPanel(panel) {
    this.setState({
      lastPanel: panel,
    });
  }

  goToLastState() {
    this.setState({
      'selectedPanel': this.state.lastPanel,
    });
  }

  changeRightPanel(panel) {
    this.setState({
      'selectedPanel': panel,
    });
  }

  changeProductResults(input) {
    this.setState({
      results: input,
    });
  }

  renderLeftPanel() {
    if (this.state.login) {
      return (
        <React.Fragment>
          <Login
            closeLogin={this.closeLoginPanel.bind(this)}
          />
        </React.Fragment>
      )
    } else {
      return (
        <React.Fragment>
          <LeftPanel
            openLogin={this.openLoginPanel.bind(this)}
          />
          <RightPanel
            panel={this.state.selectedPanel}
            goToLastState={this.goToLastState}
            results={this.state.results}
          />
        </React.Fragment>
      )
    }
  }

  openLoginPanel() {
    this.setState({
      login: true
    });
  }

  closeLoginPanel() {
    console.log("Hey");
    this.setState({
      login: false
    });
  }

  render() {
    return (
      <div className="app">
        <TopBar
          onChangeRightPanel={this.changeRightPanel.bind(this)}
          changeResults={this.changeProductResults}
          goToLastState={this.goToLastState}
          openLogin={this.openLoginPanel.bind(this)}
        />
        <div className="panels">
          {this.renderLeftPanel()}
        </div>
        <Nav
          changeLastPanel={this.changeLastPanel.bind(this)}
          onChangeRightPanel={this.changeRightPanel.bind(this)}
        />
      </div>
    );
  }
}

export default App;
