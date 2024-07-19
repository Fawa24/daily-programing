var viewModel = function() {
  var self=this; 
  self.todo = ko.observable('Create responsive UI component using KnockoutJS'),
  self.completed = ko.observable('No'),
  self.state = ko.computed({
    read: function() { return self.todo() + ": " + self.completed === 'Yes' ? 'Completed' : 'NotCompleted' },
    write: function(value) {
      var arrName = value.split(' ')
      self.todo(arrName[0])
      self.completed(arrName[1])
    }
  })
}

ko.applyBindings(viewModel);