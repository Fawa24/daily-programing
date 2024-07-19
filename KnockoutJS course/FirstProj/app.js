var viewModel = {
  todo: ko.observable('Create responsive UI component using KnockoutJS'),
  completed: 'No',
  works: 'Yes'
}

ko.applyBindings(viewModel);