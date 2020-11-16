/* eslint react/prop-types: 0 */

import '../assets/css/RightPanel.css';
import React from 'react';
import Catalog from './Catalog';
import Cart from './Cart';
import Map from './Map';
import Searcher from './SearchPanel';
import Square from './Square';
import {requestMap} from '../requests/MapRequest';
import {requestCatalog} from '../requests/ProductRequest.js';
import loadingGif from '../assets/images/loading.gif';

// minimum width is 70
const WIDTHS = {
  CART: '130%',
  CATALOG: '270%',
  MAP: '250%',
  SEARCHER: '250%',
};
class RightPanel extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      'componentDidMount': false,
      'map': [],
      'catalog': [],
      'catalogPage': 0,
      'initialCatalog': [],
    };
    this.currentPanel = this.currentPanel.bind(this);
    this.catalogRef = React.createRef();
    this.loadingRef = React.createRef();
    this.searchPanelRef = React.createRef();
  }


  componentDidMount() {
    this.setState({
      'componentDidMount': true,
    });
    this.hideLoading();
    this.initializeMap();
    this.initializeCatalog();
  }


  async initializeCatalog() {
    const catalog = await requestCatalog(0);
    this.setState({
      'initialCatalog': catalog,
      'catalog': catalog,
      'catalogPage': 1,
    });
    if (this.catalogRef.current !== null) {
      this.catalogRef.current.updateCatalog(catalog);
    }
  }

  async updateCatalog(page) {
    this.showLoading();
    const catalog = await requestCatalog(this.state.catalogPage);
    this.setState({
      'catalog': catalog,
      'catalogPage': page,
    });
    if (this.catalogRef.current !== null) {
      this.catalogRef.current.updateCatalog(catalog);
    }
    this.hideLoading();
  }

  resetCatalog() {
    this.setState({
      'catalog': this.state.initialCatalog,
      'catalogPage': 1,
    });
    if (this.catalogRef.current !== null) {
      this.catalogRef.current.updateCatalog(this.state.initialCatalog);
    }
  }

  async initializeMap() {
    const map = await requestMap();
    this.drawMap(map);
  }
  drawMap(map) {
    for (let x = 0; x < map.length; x++) {
      for (let y = 0; y < map[x].length; y++) {
        const right = map[x][y + 1];
        let down;
        if (x + 1 < map.length) {
          down = map[x + 1][y];
        }
        let needsShadow = false;
        if (right == 0 || down == 0) needsShadow = true;
        map[x][y] = (
          <Square
            key={(x, y)}
            shadow={needsShadow}
            color={map[x][y]} x={x} y={y}
          />);
      }
    }
    this.setState({
      'map': map,
    });
  }

  currentPanel() {
    return this.changePanel(this.props.panel);
  }

  updateSearchPanel(input) {
    if (this.searchPanelRef.current !== null) {
      this.searchPanelRef.current.updateResults(input);
    }
  }

  changeCompletedSearchResultsPanel(input) {
    if (this.searchPanelRef.current !== null) {
      this.searchPanelRef.current.changeCompletedSearch(input);
    }
  }

  scrollToTopResultsPanel() {
    if (this.searchPanelRef.current !== null) {
      this.searchPanelRef.current.scrollToTop();
    }
  }

  searchMoreResults() {
    this.props.moreResults();
  }


  changePanel(input) {
    const panel = input;
    if (panel === 'cart') {
      this.changePanelWidth(WIDTHS.CART);
      return <Cart />;
    } else if (panel === 'catalog') {
      this.changePanelWidth(WIDTHS.CATALOG);
      return <Catalog
        catalog={this.state.catalog}
        ref={this.catalogRef}
        onGoToPage={(page) => this.updateCatalog(page)}
        page={this.state.catalogPage}
      />;
    } else if (panel === 'map') {
      this.changePanelWidth(WIDTHS.MAP);
      return <Map map={this.state.map} />;
    } else if (panel === 'searcher') {
      this.changePanelWidth(WIDTHS.SEARCHER);
      return (
        <Searcher
          ref={this.searchPanelRef}
          goToLastState={this.props.goToLastState}
          onResultsBottomPage={() => this.searchMoreResults()}
        />
      );
    }
  }


  changePanelWidth(width) {
    if (this.state.componentDidMount) {
      const rightPanel = document.querySelector('.right-panel');
      rightPanel.style.width = width;
    }
  }

  showLoading() {
    this.loadingRef.current.style.display = 'inherit';
  }
  hideLoading() {
    this.loadingRef.current.style.display = 'none';
  }

  render() {
    return (
      <div className="right-panel">
        <this.currentPanel panel={this.props.panel} />
        <img
          src={loadingGif}
          className="loading-gif"
          ref={this.loadingRef}></img>
      </div>
    );
  }
}

export default RightPanel;
