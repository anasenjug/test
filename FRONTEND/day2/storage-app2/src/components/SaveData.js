const handleSaveData = (tableData) => {
    localStorage.setItem('savedData', JSON.stringify(tableData));
    alert('Data saved to local storage');
};
export default handleSaveData;