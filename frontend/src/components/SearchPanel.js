/* eslint react/prop-types: 0 */
import '../assets/css/SearchPanel.css';
import leftArrow from '../assets/images/left_arrow.png';
import React from 'react';
import Result from './SearchResult';
import {withTranslation} from 'react-i18next';

class SearchPanel extends React.Component {
  constructor(props) {
    super(props);
  }

  handleScroll(element) {
    const bottomPosition = (element.target.scrollHeight -
      element.target.offsetHeight);
    const currentPosition = element.target.scrollTop;
    if (currentPosition === bottomPosition) {
      this.props.onResultsBottomPage();
    }
  }

  renderResults() {
    return this.props.results.map((result) =>
      <Result key={result.barcode} productData={result} />,
    );
  }

  getResultsNumber() {
    const {t} = this.props;
    if (this.props.completedSearch) {
      const results = this.props.results.length;
      console.log(results);
      if (results > 0) {
        return t('searchSomeResults', {results: results});
      }
      return t('searchNoResults');
    } else {
      return t('searching');
    }
  }

  render() {
    const {t} = this.props;
    return (
      <div className="searcher">
        <div className="searcher-title">{this.getResultsNumber()}</div>
        <div className="searcher-results"
          onScroll={(e) => this.handleScroll(e)}>
          {this.renderResults()}
        </div>
        <div className="searcher-buttons">
          <button className="return-button" onClick={this.props.goToLastState}>
            <img className="return-button-image" src={leftArrow}></img>
            <div className="return-button-text">{t('return')}</div>
          </button>
        </div>
      </div>
    );
  }
}

export default withTranslation()(SearchPanel);
