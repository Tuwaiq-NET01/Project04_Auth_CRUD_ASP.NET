const Storage = (function() {
	let myStorage = window.localStorage;

	function get(name) {
		return myStorage.getItem(name);
	}

	function set(name, value) {
		myStorage.setItem(name, value);
	}

	function remove(name) {
		myStorage.removeItem(name);
	}

	return {
		get,
		set,
		remove
	};
})();

export default Storage;
