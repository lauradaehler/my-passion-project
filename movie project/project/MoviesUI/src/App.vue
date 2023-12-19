<template>
	<div class="container">
		<h1>Mayvue Movies Collection</h1>
		<br/>
		<MoviesTable />
		<modal></modal>
	</div>
</template>

<script setup>
import MoviesTable from './components/MoviesTable.vue';
import Modal from './components/Modal.vue';

</script>

<style scoped>
.hidden {
  display: none;
}
</style>
