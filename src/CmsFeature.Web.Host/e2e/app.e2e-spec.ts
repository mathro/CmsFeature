import { CmsFeatureTemplatePage } from './app.po';

describe('CmsFeature App', function() {
  let page: CmsFeatureTemplatePage;

  beforeEach(() => {
    page = new CmsFeatureTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
