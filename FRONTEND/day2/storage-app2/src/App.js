import './App.css';
import React, { useState } from 'react';
import {Button} from './components';

const App = () => {
  const data='';
  const [tableData, setTableData] = useState([]);
  const [formData, setFormData] = useState({ name: '', age: '' });
  const [editIndex, setEditIndex] = useState(-1);

  const handleSaveData = () => {
    localStorage.setItem('savedData', JSON.stringify(tableData));
    alert('Data saved to local storage');
  };

  const handleRetrieveData = () => {
    const savedData = localStorage.getItem('savedData');
    if (savedData) {
      setTableData(JSON.parse(savedData));
      alert('Data retrieved from local storage');
    }
  };

  const handleFormSubmit = (e) => {
    e.preventDefault();
    if (editIndex !== -1) {
      const newData = [...tableData];
      newData[editIndex] = formData;
      setTableData(newData);
      setEditIndex(-1);
    } else {
      setTableData([...tableData, formData]);
    }
    setFormData({ name: '', age: '' });
  };

  const handleEdit = (index) => {
    setFormData(tableData[index]);
    setEditIndex(index);
  };

  const handleRemove = (index) => {
    const newData = tableData.filter((_, i) => i !== index);
    setTableData(newData);
  };

  return (
    <div className='App'>
      <h1>Local Storage App</h1>
      <form onSubmit={handleFormSubmit}>
        <label>
          Name:
          <input
            type='text'
            value={formData.name}
            onChange={(e) => setFormData({ ...formData, name: e.target.value })}
            placeholder='Enter name'
          />
        </label>
        <label>
          Age:
          <input
            type='text'
            value={formData.age}
            onChange={(e) => setFormData({ ...formData, age: e.target.value })}
            placeholder='Enter age'
          />
        </label>
        <Button type='submit'>{editIndex !== -1 ? 'Update' : 'Add to Table'}</Button>
      </form>
      <Button onClick={handleSaveData}>Save to local storage</Button>
      <Button onClick={handleRetrieveData}>Retrieve data from local storage</Button>
      <p>Saved Data: {JSON.stringify(tableData)}</p>
      <table>
        <thead>
          <tr>
            <th>Name</th>
            <th>Age</th>
            <th>Edit</th>
            <th>Remove</th>
          </tr>
        </thead>
        <tbody>
          {tableData.map((row, index) => (
            <tr key={index}>
              <td>{row.name}</td>
              <td>{row.age}</td>
              <td>
                <Button onClick={() => handleEdit(index)}>Edit</Button>
              </td>
              <td>
                <Button onClick={() => handleRemove(index)}>Remove</Button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default App;