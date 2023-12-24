<template>
	<div class="container">
		<h1>Mayvue Movies Collection</h1>
		<MoviesTable />
	</div>
</template>

<script setup>
import MoviesTable from './components/MoviesTable.vue'

</script>



<style scoped>
.container {
	font-family: 'Courier New', Courier, monospace;
	padding-top: 10px;
}

h1 {
	color: rgb(255, 78, 160);
}

.hidden {
  display: none;
}
</style>
