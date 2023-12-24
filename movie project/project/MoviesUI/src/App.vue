<script setup>
import MoviesTable from './components/MoviesTable.vue'
</script>

<template class="app">
	<div class="container">
		<h1>Mayvue Movies Collection</h1>
		<MoviesTable />
	</div>
</template>

<style scoped>
.container {
	font-family: 'Courier New', Courier, monospace;
	padding-top: 10px;

}

h1 {
    color: rgb(253, 17, 127);
	font-size: 50px;
	font-weight: 500;
}

.hidden {
  display: none;
}

</style>
